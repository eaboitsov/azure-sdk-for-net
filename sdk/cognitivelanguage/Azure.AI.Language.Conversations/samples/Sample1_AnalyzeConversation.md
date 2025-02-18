# Analyze a conversation

This sample demonstrates how to analyze an utterance. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversation
Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
    "Menu",
    "production",
    "We'll have 2 plates of seared salmon nigiri.");

Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
```

## Asynchronous

```C# Snippet:ConversationAnalysis_AnalyzeConversationAsync
Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
    "Menu",
    "production",
    "We'll have 2 plates of seared salmon nigiri.");

Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
```
