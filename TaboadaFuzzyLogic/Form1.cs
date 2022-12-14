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
        Queue<int> lldh = new Queue<int>(); // Love = 1, Like = 2, Dislike = 3, Hate = 4
        int loveCount, likeCount, dislikeCount, hateCount;

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

        public void SetRules()
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

        public void SetFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myLove);
            fe.LinguisticVariableCollection.Add(myLike);
            fe.LinguisticVariableCollection.Add(myDislike);
            fe.LinguisticVariableCollection.Add(myHate);
            fe.LinguisticVariableCollection.Add(myStatus);
            fe.FuzzyRuleCollection = myRule;
        }

        public void Forgor()
        {
            switch (lldh.Dequeue())
            {
                case 1:
                    loveCount--;
                    break;
                case 2:
                    likeCount--;
                    break;
                case 3:
                    dislikeCount--;
                    break;
                case 4:
                    hateCount--;
                    break;
            }
        }

        public void UpdateStatus()
        {
            fe.Consequent = "STATUS";
            if(lldh.Count < 30)
            {
                textBox2.Text = "NOT ENOUGH POINTS";
            }
            else textBox2.Text = "" + fe.Defuzzify();
        }

        public void UpdateFP()
        {
            textBox1.Text = "Love = " + loveCount + ", Like = " + likeCount + ", Dislike = " + dislikeCount + ", Hate = " + hateCount;
        }

        public void FuzzyBlock()
        {
            UpdateFP();
            myLove.InputValue = loveCount;
            myLike.InputValue = likeCount;
            myDislike.InputValue = dislikeCount;
            myHate.InputValue = hateCount;
            myLove.Fuzzify("MODERATE");
            myLike.Fuzzify("MODERATE");
            myDislike.Fuzzify("MODERATE");
            myHate.Fuzzify("MODERATE");
            SetFuzzyEngine();
            UpdateStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetMembers();
            SetRules();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lldh.Count < 30)
            {
                lldh.Enqueue(1);
                loveCount++;
            }
            else
            {
                Forgor();
                lldh.Enqueue(1);
                loveCount++;
            }
            FuzzyBlock();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lldh.Count < 30)
            {
                lldh.Enqueue(2);
                likeCount++;
            }
            else
            {
                Forgor();
                lldh.Enqueue(2);
                likeCount++;
            }
            FuzzyBlock();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lldh.Count < 30)
            {
                lldh.Enqueue(3);
                dislikeCount++;
            }
            else
            {
                Forgor();
                lldh.Enqueue(3);
                dislikeCount++;
            }
            FuzzyBlock();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lldh.Count < 30)
            {
                lldh.Enqueue(4);
                hateCount++;
            }
            else
            {
                Forgor();
                lldh.Enqueue(1);
                hateCount++;
            }
            FuzzyBlock();
        }
    }
}
