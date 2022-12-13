using System;
using System.Collections;
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
        MembershipFunctionCollection love, like, dislike, hate, status;
        LinguisticVariable myLove, myLike, myDislike, myHate, myStatus;
        FuzzyRuleCollection myRule;
        Queue<int> lldh = new Queue<int>();

        public Form1()
        {
            InitializeComponent();
        }

        public void SetMembers()
        {
            love = new MembershipFunctionCollection();
            love.Add(new MembershipFunction("LOW", 0.0, 0.0, 10.0, 12.0));
            love.Add(new MembershipFunction("MODERATE", 11.0, 15.0, 15.0, 22.0));
            love.Add(new MembershipFunction("HIGH", 21.0, 25.0, 30.0, 30.0));
            myLove = new LinguisticVariable("LOVE", love);

            like = new MembershipFunctionCollection();
            like.Add(new MembershipFunction("LOW", 0.0, 0.0, 10.0, 12.0));
            like.Add(new MembershipFunction("MODERATE", 11.0, 15.0, 15.0, 22.0));
            like.Add(new MembershipFunction("HIGH", 21.0, 25.0, 30.0, 30.0));
            myLike = new LinguisticVariable("LIKE", like);

            dislike = new MembershipFunctionCollection();
            dislike.Add(new MembershipFunction("LOW", 0.0, 0.0, 10.0, 12.0));
            dislike.Add(new MembershipFunction("MODERATE", 11.0, 15.0, 20.0, 22.0));
            dislike.Add(new MembershipFunction("HIGH", 21.0, 25.0, 30.0, 30.0));
            myDislike = new LinguisticVariable("DISLIKE", dislike);

            hate = new MembershipFunctionCollection();
            hate.Add(new MembershipFunction("LOW", 0.0, 0.0, 10.0, 12.0));
            hate.Add(new MembershipFunction("MODERATE", 11.0, 15.0, 15.0, 22.0));
            hate.Add(new MembershipFunction("HIGH", 21.0, 25.0, 30.0, 30.0));
            myHate = new LinguisticVariable("HATE", hate);

            status = new MembershipFunctionCollection();
            status.Add(new MembershipFunction("HATE", 0.0, 0.0, 1.0, 2.0));
            status.Add(new MembershipFunction("DISLIKE", 1.0, 2.0, 4.0, 6.0));
            status.Add(new MembershipFunction("NEUTRAL", 4.0, 5.0, 6.0, 7.0));
            status.Add(new MembershipFunction("LIKE", 5.0, 8.0, 11.0, 12.0));
            status.Add(new MembershipFunction("LOVE", 10.0, 13.0, 14.0, 14.0));
            myStatus = new LinguisticVariable("STATUS", status);
        }

        public void setRules()
        {
            myRule = new FuzzyRuleCollection();
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS LOW) AND (DISLIKE IS LOW) AND (HATE IS LOW) THEN STATUS IS NEUTRAL"));
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS MODERATE) AND (DISLIKE IS LOW) AND (HATE IS LOW) THEN STATUS IS LIKE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS MODERATE) AND (LIKE IS LOW) AND (DISLIKE IS LOW) AND (HATE IS LOW) THEN STATUS IS LOVE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS LOW) AND (DISLIKE IS MODERATE) AND (HATE IS LOW) THEN STATUS IS DISLIKE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS LOW) AND (DISLIKE IS LOW) AND (HATE IS MODERATE) THEN STATUS IS HATE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS HIGH) AND (DISLIKE IS LOW) AND (HATE IS LOW) THEN STATUS IS LIKE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS HIGH) AND (LIKE IS LOW) AND (DISLIKE IS LOW) AND (HATE IS LOW) THEN STATUS IS LOVE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS LOW) AND (DISLIKE IS HIGH) AND (HATE IS LOW) THEN STATUS IS DISLIKE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS LOW) AND (LIKE IS LOW) AND (DISLIKE IS LOW) AND (HATE IS HIGH) THEN STATUS IS HATE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS MODERATE) AND (LIKE IS MODERATE) AND (DISLIKE IS LOW) AND (HATE IS LOW) THEN STATUS IS LIKE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS MODERATE) AND (LIKE IS LOW) AND (DISLIKE IS MODERATE) AND (HATE IS LOW) THEN STATUS IS DISLIKE"));
            myRule.Add(new FuzzyRule("IF (LOVE IS MODERATE) AND (LIKE IS LOW) AND (DISLIKE IS LOW) AND (HATE IS MODERATE) THEN STATUS IS NEUTRAL"));
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myLove);
            fe.LinguisticVariableCollection.Add(myLike);
            fe.LinguisticVariableCollection.Add(myDislike);
            fe.LinguisticVariableCollection.Add(myHate);
            fe.LinguisticVariableCollection.Add(myStatus);
            fe.FuzzyRuleCollection = myRule;
        }
    }
}
