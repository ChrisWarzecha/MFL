using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class DeveloperConsole : MonoBehaviour
    {
        [Header("Console Colors")] 
        [Range(0f,1f)]
        public float transparency;
        
        [Header("UI Components")] 
        public GameObject console;
        public InputField consoleInput;
        public Text consoleText;
        public Text inputText;
        private CanvasGroup commandCanvasGroup;

        [Header("Console Button")]
        public KeyCode consoleButton;

        private int _maxChars = 10000;
        public static bool logTime = true;

        public static void SetLogTime(bool val)
        {
            logTime = val;
        }
        
        public static Dictionary<string, Delegate> Commands { get; private set; }
        public static Dictionary<string, string> Helps { get; private set; }

        [TextArea]     
        public string additionalHelpText;

        private bool _inputFocused;

        private string _lastCommand;

        private bool _isEnabled = false;

        public static DeveloperConsole instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance);
            }

            instance = this;
            
            commandCanvasGroup = GetComponentInChildren<CanvasGroup>();
            commandCanvasGroup.alpha = transparency;
            
            Commands = new Dictionary<string, Delegate>();
            Helps = new Dictionary<string, string>();
            
            AddDescriptionAttributes();
            
            console.SetActive(_isEnabled);
        }

        //Add Custom TypeConverter for Unity here
        public void AddDescriptionAttributes()
        {
            TypeDescriptor.AddAttributes(typeof(Vector2), new TypeConverterAttribute(typeof(Vector2Converter)));
            TypeDescriptor.AddAttributes(typeof(Vector3), new TypeConverterAttribute(typeof(Vector3Converter)));
            TypeDescriptor.AddAttributes(typeof(Vector4), new TypeConverterAttribute(typeof(Vector4Converter)));
        }

        private void Start()
        {
            Initialize();
            PrintHelp();
        }

        private void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        private void HandleLog(string logMessage, string stackTrace, LogType type)
        {
            string typeColor;

            switch (type)
            {
                case LogType.Error:
                    typeColor = "red";
                    break;
                case LogType.Assert:
                    typeColor = "silver";
                    break;
                case LogType.Warning:
                    typeColor = "yellow";
                    break;
                case LogType.Log:
                    typeColor = "silver";
                    break;
                case LogType.Exception:
                    typeColor = "red";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            string _message = "<color=" + typeColor + ">";
            _message += "[" + type + "] " + logMessage;
            _message += "</color>";
            AddMessageToConsole(_message);
        }

        public void Initialize()
        {
            Debug.Log("Initializing Console Commands \n");
            

            // Load Up All Attributed Functions
            var executingAssembly = Assembly.GetExecutingAssembly();
            var executingMethods = executingAssembly
                .GetTypes()
                .SelectMany(x => x.GetMethods())
                .Where(y => y.GetCustomAttributes().OfType<CC>().Any())
                .ToDictionary(z => z.Name);

            var stringBulider = new StringBuilder();

            foreach (var methodInfoKVP in executingMethods)
            {
                ////////////////////////////////////////////////////////////////

                var methodInfo = methodInfoKVP.Value;
                var parameterInfos = methodInfo.GetParameters();
                var returnsVoid = methodInfoKVP.Value.ReturnType == typeof(void);

                // Find delegate type
                Type delegateType = null;
                switch (parameterInfos.Length)
                {
                    case 0:
                        delegateType = returnsVoid ? typeof(Action) : typeof(Func<>);
                        break;
                    case 1:
                        delegateType = returnsVoid ? typeof(Action<>) : typeof(Func<,>);
                        break;
                    case 2:
                        delegateType = returnsVoid ? typeof(Action<,>) : typeof(Func<,,>);
                        break;
                    case 3:
                        delegateType = returnsVoid ? typeof(Action<,,>) : typeof(Func<,,,>);
                        break;
                    case 4:
                        delegateType = returnsVoid ? typeof(Action<,,,>) : typeof(Func<,,,,>);
                        break;
                    case 5:
                        delegateType = returnsVoid ? typeof(Action<,,,,>) : typeof(Func<,,,,,>);
                        break;
                }

                if (delegateType == null)
                {
                    Debug.LogError(
                        "Console does not accept methods with more than 6 parameters yet. You can easily add handling for more!");
                    continue;
                }

                var constructedDelegate = delegateType;

                var skipGenericConstruction = parameterInfos.Length == 0 && returnsVoid;
                if (!skipGenericConstruction)
                {
                    // if we have parameters, we need to construct the delegate type (fill in the generic parameters) 
                    // Otherwise, we can just accept the delegate type!.

                    // Create array of generic parameters (method return type + method parameter types
                    var nonVoidReturnParameterOffset = returnsVoid ? 0 : 1;
                    var typeArgs = new Type[parameterInfos.Length + nonVoidReturnParameterOffset];

                    if (!returnsVoid) typeArgs[typeArgs.Length - 1] = methodInfo.ReturnType;

                    for (var i = 0; i < parameterInfos.Length; i++) typeArgs[i] = parameterInfos[i].ParameterType;

                    // Construct final delegate type
                    constructedDelegate = delegateType.MakeGenericType(typeArgs);
                }

                // Create delegate and save it!
                CC MyAttribute = (CC) Attribute.GetCustomAttribute(methodInfoKVP.Value, typeof (CC));
                Commands.Add(methodInfoKVP.Key.ToLower(),methodInfo.CreateDelegate(constructedDelegate));
                
                // Create helper and save it!
                Helps.Add(methodInfoKVP.Key.ToLower(),MyAttribute.Help());


                stringBulider.Append("Method " + methodInfoKVP.Value.DeclaringType + "." + methodInfoKVP.Key +
                                     " exposed as \"" + methodInfoKVP.Key + "\"\n");
            }
            
            Debug.Log("Console Ready for Comments \n");
        }

        private void Update()
        {
            
            if (_isEnabled)
            {
                if (consoleText.text.Length > _maxChars)
                {
                    consoleText.text = consoleText.text.Remove(0, consoleText.text.Length - _maxChars);
                }
                _inputFocused = consoleInput.isFocused;
            }
            
            commandCanvasGroup.alpha = transparency;
        }

        public void SwitchConsole()
        {
            _isEnabled = !_isEnabled;
            console.SetActive(_isEnabled);
            consoleInput.Select();
        }

        public void EnterInput()
        {
            if (_inputFocused)
            {
                SubmitInput();
            }
        }

        public void GetLastInput()
        {
            if (_inputFocused)
            {
                consoleInput.text = _lastCommand;
                consoleInput.MoveTextEnd(false);
            }
        }

        private void SubmitInput()
        {
            if (inputText.text != "")
            {
                //AddMessageToConsole(inputText.text);
                ParseInput(inputText.text);
            }
        }

        private void AddMessageToConsole(string msg)
        {
            if (DeveloperConsole.logTime)
            {
                string timeMsg = "<color=#6effe2>[" + System.DateTime.Now.ToLongTimeString()+"]</color> ";
                timeMsg += msg;
                msg = timeMsg;
            }
            consoleText.text += msg + "\n";
        }

        private void ParseInput(string input)
        {
            if (input.StartsWith(" "))
            {
                ParseInput(input.Remove(0,1));
                return;
            }

            _lastCommand = input;

            AddMessageToConsole(input);
            
            string[] CommandAndParameters = input.Split(' ');
            
            
            if (input.Length == 0 || input == null)
            {
                Debug.LogWarning("Command not recognized.");
                return;
            }

            if (input.ToLower().Equals("help"))
            {
                PrintHelp();
            }
            else if (!Commands.ContainsKey(CommandAndParameters[0].ToLower()) && CommandAndParameters[0].ToLower() != "help")
                Debug.LogWarning("Command not recognized.");
            else
            {
                if (CommandAndParameters[0].ToLower() == "help")
                {
                    if (Helps.ContainsKey(CommandAndParameters[1].ToLower()))
                    {
                        Debug.Log(Helps[CommandAndParameters[1].ToLower()]);
                    }
                    else
                    {
                        Debug.LogWarning("Command for help not recognized.");
                    }
                }
                else if (Commands[CommandAndParameters[0].ToLower()].Method.GetParameters().Length == 0)
                {
                    Commands[CommandAndParameters[0].ToLower()].DynamicInvoke();
                    AddMessageToConsole(CommandAndParameters[0].ToLower() + " succesfully invoked");
                }
                else
                {
                    var parameterInfos = Commands[CommandAndParameters[0].ToLower()].Method.GetParameters();
                    
                    string[] parameterStrings = new string[CommandAndParameters.Length-1];

                    Array.Copy(CommandAndParameters,1,parameterStrings,0,CommandAndParameters.Length-1);
                    
                    Commands[CommandAndParameters[0].ToLower()].DynamicInvoke(ParseParameter(parameterStrings, parameterInfos));
                
                    AddMessageToConsole(CommandAndParameters[0].ToLower() + " succesfully invoked with Parameters");
                }
            }

            consoleText.text += "\n";
            
            consoleInput.text = "";
            consoleInput.Select();
            consoleInput.ActivateInputField();
        }

        private void PrintHelp()
        {
            string helpText = "";

            helpText += "<color=#6effe2>[" + System.DateTime.Now.ToLongTimeString() + "]</color>\n";
            helpText += " -- Help --\n";
            helpText += "\n";
            helpText += additionalHelpText;
            helpText += "\n";
            helpText += "\n";
            helpText += "Command - Help Information";
            helpText += "\n";
            helpText += "_____________________________________________________\n    ";
            helpText += "\n<color=silver>";


            foreach (var helpKVP in Helps)
            {
                helpText += helpKVP.Key + " - " + helpKVP.Value + "\n";
            }
            
            helpText += "</color>\n";

            consoleText.text += helpText;
        }

        private object[] ParseParameter(string[] parameterStrings, ParameterInfo[] infos)
        {
            object[] parameters = new object[infos.Length];

            for (var i = 0; i < infos.Length; i++)
            {
                try
                {
                    parameters[i] = TypeDescriptor.GetConverter(infos[i].ParameterType)
                        .ConvertFromString(parameterStrings[i]);
                }
                catch (NotSupportedException e)
                {
                    Debug.LogError("Can not convert " + parameterStrings[i] + " to type " + infos[i].ParameterType +".\n" +e.Message);
                }
            }

            return parameters;
        }

        [CC("Prints a Debug Log Message")]
        public static void Log(string message)
        {
            Debug.Log(message);
        }

        [CC("Prints a Debug Log Error Message")]
        public static void Log_Error(string message)
        {
            Debug.LogError(message);
        }
        
        [CC("Prints a Debug Log Warning Message")]
        public static void Log_Warning(string message)
        {
            Debug.LogWarning(message);
        }

    }
}