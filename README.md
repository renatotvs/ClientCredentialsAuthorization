# ClientCredentialsAuthorization

Console Application .net Core

Exemplo C# (Console Application .net Core) - Obter Token de Acesso a API via credenciais.

*Objetivo:* Garantir que solicitações HTTP de serviços de back-end que tenham o API Gateway como origem, através de credentials obter o Token de acesso as outras API´s assim garantindo autenticidade do solicitante.

No arquivo: Program.cs possui dois métodos:

+ Obter token de acesso (através de credentials)

private static async Task<string> GetToken()
{
  
}

+ Obter acesso conteúdo API (através do token de acesso)

private static async Task<string> GetAPI()
{
  
}
