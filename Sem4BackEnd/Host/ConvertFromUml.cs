using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Host {
    public partial class ConvertFromUml : Form {
        public ConvertFromUml() {
            InitializeComponent();
        }

        private void btnFieldProperty_Click(object sender, EventArgs e) {
            List<String> fields = new List<String>();
            List<Variable> vars = ParseInput();
            //////////Convert variable type objects to viariable/properties

            foreach(Variable var in vars) {
                fields.Add(var.toField(true));
            }
            foreach(Variable prop in vars) {
                fields.Add(prop.toProperty(true));
            }

            rtbOutputProperties.Text = String.Join("\n", fields);
        }

        private void btnProp_Click(object sender, EventArgs e) {
            List<String> fields = new List<String>();
            List<Variable> vars = ParseInput();
            //////////Convert variable type objects to viariable/properties

            foreach(Variable prop in vars) {
                fields.Add(prop.toProperty());
            }

            rtbOutputProperties.Text = String.Join("\n", fields);
        }

        private List<Variable> ParseInput() {
            //////////Initiate variables
            String[] startValues = rtbInputProperties.Lines; //Converts the input into string array of lines
            String[] preProcessedValues = new String[startValues.Length]; //Specify the size acording to the input line count
            int indx;

            //////////trim whitespace before processing

            indx = 0;
            foreach(String s in startValues) {
                String sTemp = s.Replace(":", "").Trim();
                sTemp = String.Join(" ", sTemp.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                preProcessedValues[indx++] = sTemp;
            }
            preProcessedValues = preProcessedValues.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //////////Convert to variable type objects

            return createVariables(preProcessedValues);
        }

        private List<Variable> createVariables(String[] startValues) {
            List<Variable> variables = new List<Variable>();

            //////////
            foreach(String s in startValues) {
                String sr;
                if(s.Substring(0, 1) == "+") {
                    sr = s.Replace("+", "public ");
                }
                else if(s.Substring(0, 1) == "-") {
                    sr = s.Replace("-", "private ");
                }
                else {
                    sr = s;
                }

                String[] sTemp = sr.Trim().Split(' ');
                if(sTemp.Length == 3) {
                    Variable v = new Variable();
                    if(sTemp[0] == "private" || sTemp[0] == "public") {
                        v.visability = sTemp[0];
                        v.name = sTemp[1];
                        v.type = sTemp[2];
                    }
                    variables.Add(v);
                }
                else if(sTemp.Length == 4) {
                    Variable v = new Variable();
                    if(sTemp[0] == "private" || sTemp[0] == "public") {
                        v.visability = sTemp[0];
                        v.name = sTemp[1];
                        v.type = sTemp[2] + " " + sTemp[3];
                    }
                    variables.Add(v);
                }
            }

            return variables;
        }

        public class Variable {
            public String name;
            public String type;
            public String visability;

            public String toField(bool usingProperty = false) {
                if(name == null || type == null) {
                    throw new NullReferenceException();
                }
                String value = type + " " + name + ";\n";
                if(usingProperty) {
                        value = "private " + value;
                }
                else {
                    if(visability != null) {
                        value = visability + " " + value;
                    }
                }
                return value;
            }

            public String toProperty(bool usefields = false) {
                if(name == null || type == null) {
                    throw new NullReferenceException();
                }
                String upperName = char.ToUpper(name[0]) + name.Substring(1);
                String value = type + " " + upperName + "{\n";
                if(visability != null) {
                    value = visability + " " + value;
                }
                if(usefields) {
                    value += "    get{\n";
                    value += "        return " + name + ";\n";
                    value += "    }\n";
                    value += "    set{\n";
                    value += "        " + name + " = value;\n";
                    value += "    }\n";
                    value += "}";
                }
                else {
                    value += "    get;" + "\n";
                    value += "    set;" + "\n";
                    value += "}";
                }
                return value;
            }
        }
    }
}
