using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

namespace AppendPrependInMethod
{
    class AppendPrepend
    {
        private const int TAB_SPACE = 4;

        public static string MethodRegex
        {
            get
            {
                return ConfigurationManager.AppSettings["functionRegex"];
            }
        }

        public AppendPrepend(string filePath)
        {
            this.filePath = filePath;
        }

        public void Insert(string preText, string postText)
        {
            FileStream fs = File.Open(this.filePath, FileMode.Open);

            using (StreamReader sr = new StreamReader(fs))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int cursorInx = 0;
                string text = sr.ReadToEnd();

                while (Regex.IsMatch(text.Substring(cursorInx), MethodRegex))
                {
                    var restOfText = text.Substring(cursorInx);
                    Match match = Regex.Match(restOfText, MethodRegex);
                    int numofSpaceForIndentation = Regex.Match(match.Value, @"[\s]*").Value.Length + TAB_SPACE;


                    //first post block must be inserted
                    text = InsertPostBlock(text, numofSpaceForIndentation, restOfText, cursorInx, match.Index + match.Length, postText);

                    text = InsertPreBlock(text, numofSpaceForIndentation, cursorInx + match.Index + match.Length, preText);

                    //advance forward
                    cursorInx = cursorInx + match.Index + match.Length;
                }

            }


            fs.Close();
        }

        public void Insert(string preText, string postText, string[] methodsSignaturesMustMatchRegex)
        {
            FileStream fs = File.Open(this.filePath, FileMode.Open);

            using (StreamReader sr = new StreamReader(fs))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int cursorInx = 0;
                string text = sr.ReadToEnd();

                while (Regex.IsMatch(text.Substring(cursorInx), MethodRegex))
                {
                    var restOfText = text.Substring(cursorInx);
                    Match match = Regex.Match(restOfText, MethodRegex);

                    bool matchesAtleasOne = false;
                    foreach (string methodSignature in methodsSignaturesMustMatchRegex)
                    {
                        if (Regex.IsMatch(match.Value, Regex.Escape(methodSignature)))
                        {
                            matchesAtleasOne = true;
                            break;
                        }
                    }

                    if (matchesAtleasOne)
                    {
                        int numofSpaceForIndentation = Regex.Match(match.Value, @"[\s]*").Value.Length + TAB_SPACE;


                        //first post block must be inserted
                        text = InsertPostBlock(text, numofSpaceForIndentation, restOfText, cursorInx,
                                               match.Index + match.Length, postText);

                        text = InsertPreBlock(text, numofSpaceForIndentation, cursorInx + match.Index + match.Length,
                                              preText);
                    }
                    //advance forward
                    cursorInx = cursorInx + match.Index + match.Length;
                }

                fs.Seek(0, SeekOrigin.Begin);
                sw.Write(text);
                sw.Flush();
            }


            fs.Close();
        }

        protected string InsertPreBlock(string text, int numofSpaceForIndentation, int globalInx, string preText)
        {
            //insert try block
            string tryBlock = getPreBlock(numofSpaceForIndentation, preText);
            text = text.Insert(globalInx, tryBlock);
            return text;
        }

        protected string InsertPostBlock(string text, int numofSpaceForIndentation,
            string restOfText, int cursorInx, int localInx, string postText)
        {
            var stack = new Stack<bool>();
            stack.Push(true);//true : opening curly brace, false : closing curly brace

            int methodClosingCBraceInx = 0;
            var restOfMethodSignatureAndACurlyBrace = restOfText.Substring(localInx);
            var cbraces = Regex.Matches(restOfMethodSignatureAndACurlyBrace, @"[\{\}]");
            foreach (Match cbrace in cbraces)
            {
                if (cbrace.Value == "}")
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        methodClosingCBraceInx = cbrace.Index + cursorInx + localInx;
                        break;
                    }
                }
                else if (cbrace.Value == "{")
                {
                    stack.Push(true);
                }
            }


            text = text.Insert(methodClosingCBraceInx, getPostBlock(numofSpaceForIndentation, postText));

            //correct the indentation of method closing bracket            
            for (int i = 0; i < numofSpaceForIndentation - TAB_SPACE; i++)
            {
                text = text.Insert(methodClosingCBraceInx + getPostBlock(numofSpaceForIndentation, postText).Length, " ");
            }


            return text;
        }

        private string getPreBlock(int numofSpaceForIndentation, string preText)
        {
            var sr = new StringReader(preText);

            var sb = new StringBuilder();

            sb.AppendLine();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < numofSpaceForIndentation; i++)
                {
                    sb.Append(" ");
                }
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        private string getPostBlock(int numofSpaceForIndentation, string postText)
        {
            var sr = new StringReader(postText);

            var sb = new StringBuilder();


            sb.AppendLine();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < numofSpaceForIndentation; i++)
                {
                    sb.Append(" ");
                }
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        private string filePath;

    }

}
