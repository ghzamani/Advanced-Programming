using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            var mostReplied = Messages.Where(d => d.ReplyMessageId != null)
                .GroupBy(g => g.ReplyMessageId)
                .OrderByDescending(g => g.Count()).First().Key;

            foreach(var m in Messages)
            {
                if (m.Id == mostReplied)
                    return m;
            }

            return null;
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            var result = new Tuple<string, int>[5];

            var mostPostedpersons = Messages.GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Where(g => g.Key != "Sauleh Eetemadi" &&
                g.Key != "Ali Heydari").Take(5).ToArray();            

            for (int i = 0; i < 5; i++)
            {
                result[i] = new Tuple<string, int>
                    (mostPostedpersons[i].Key, mostPostedpersons[i].Count());
            }
            return result;
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            var result = new Tuple<string, int>[5];

            var mostActive = Messages.Where(d => d.DateTime.Hour <= 4)
                .GroupBy(g => g.Author).OrderByDescending(g => g.Count())
                .Take(5).ToArray();

            for (int i = 0; i < 5; i++)
            {
                result[i] = new Tuple<string, int>
                    (mostActive[i].Key, mostActive[i].Count());
            }
            return result;
        }

        public string StudentWithMostUnansweredQuestions()
        {
            List<int?> replyIds = new List<int?>();
            foreach(var m in Messages)
            {
                if(m.ReplyMessageId != null)
                    replyIds.Add(m.ReplyMessageId);
            }

            var mostUnanswered = Messages.Where(d => d.Content.Contains("?")
            || d.Content.Contains("؟")).Where(d => !replyIds.Contains(d.Id))
            .GroupBy(d => d.Author).Where(g => g.Key != "Ali Heydari")
            .OrderByDescending(g => g.Count()).First().Key;

            return mostUnanswered;
        }
    }
}