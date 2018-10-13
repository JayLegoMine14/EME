using System;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;
using Grpc.Auth;

namespace GoogleVision
{
    public class Vision
    {
            public static void Main(string[] args)
            {
                string jsonPath = @"C:\Users\Caleb\Documents\TigerHacks2018\My Project 90986-7b99496a2979.json";

                var credential = GoogleCredential.FromFile(jsonPath).CreateScoped(ImageAnnotatorClient.DefaultScopes);

                var channel = new Grpc.Core.Channel(ImageAnnotatorClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());

                var client = ImageAnnotatorClient.Create(channel);

                var image = Image.FromFile(@"c:\Users\Caleb\Pictures\myFace.jpg");

                var response = client.DetectLabels(image);

                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                        Console.WriteLine(annotation.Description);
                }
            }
        }
    }
