# Client Credentials Authorization

Exemplo C# (Console Application .net Core)

**Objetivo:** Garantir que solicitações HTTP de serviços de back-end que tenham o API Gateway como origem, através de credentials obter o Token de acesso as outras API´s assim garantindo autenticidade do solicitante.

No arquivo: <a href="https://github.com/renatotvs/ClientCredentialsAuthorization/blob/master/ClientCredentialsAuthorization/Program.cs">Program.cs</a>  possui dois métodos:

+ Obter token de acesso (através de credentials)

private static async Task<string> GetToken()
{
  
}

+ Obter acesso conteúdo API (através do token de acesso)

private static async Task<string> GetAPI()
{
  
}

