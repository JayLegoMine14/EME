using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Language.V1;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using EME.Objects;

namespace EME.Services
{
    public class NaturalLanguageAnalysis
    {
        public static Google.Cloud.Language.V1.Sentiment getSentiment(string textToAnalyze)
        {
            // Apply credential
            var credential = GoogleCredential.FromFile("Resources/EMEprivatekey.json")
                .CreateScoped(LanguageServiceClient.DefaultScopes);
            var channel = new Grpc.Core.Channel(
                LanguageServiceClient.DefaultEndpoint.ToString(),
                credential.ToChannelCredentials());

            // Get sentiment
            var client = LanguageServiceClient.Create(channel);
            var response = client.AnalyzeSentiment(new Document()
            {
                Content = textToAnalyze,
                Type = Document.Types.Type.PlainText
            });
            var sentiment = response.DocumentSentiment;

            return sentiment;
        }

        public static string sentimentToString(Google.Cloud.Language.V1.Sentiment sentiment)
        {
            string sentimentString = "";
            var score = sentiment.Score;
            var magnitude = sentiment.Magnitude;

            if ((score > 0.3))
            {
                sentimentString = "Clearly Positive";
            } else if ((score < -0.3))
            {
                sentimentString = "Clearly Negative";
            } else if ((score >= -.3) && (score <= .3))
            {
                sentimentString = "Neutral";
            } else if ((score >= -.3) && (score <= .3))
            {
                sentimentString = "Mixed";
            }

            return sentimentString;
        }

        public static List<Paragraph> analyzeSentiment(List<Paragraph> paragraphs)
        {
            foreach (Paragraph p in paragraphs) {
                Google.Cloud.Language.V1.Sentiment sentiment = getSentiment(p.Text);
                p.Sentiment = sentiment.Score;
                p.Magnitude = sentiment.Magnitude;
                p.sentimentString = sentimentToString(sentiment);
            }
            return paragraphs;
        }
    }
}
