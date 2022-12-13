using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotFuzzy;

namespace TaboadaFuzzyLogic
{
    public partial class Form1 : Form
    {
        FuzzyEngine fe;
        MembershipFunctionCollection lo, li, di, ha;
        LinguisticVariable myLo, myLi, myDi, myHa;
        FuzzyRuleCollection myRule;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
