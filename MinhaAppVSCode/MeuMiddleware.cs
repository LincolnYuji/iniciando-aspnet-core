using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class MeuMiddleware
{
    //
    // Chamada do próximo middleware dentro do pipeline
    //
    private readonly RequestDelegate _next;

    //
    // Construtor da classe recebendo uma injeção de dependencia
    //
    public MeuMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    //
    // Método chamado sempre que o middleware for chamado
    // O context é a requisição http
    //
    public async Task InvokeAsync(HttpContext context)
    {
        //
        // Neste ponto pode ser escrita a lógica do programa
        //
        Console.WriteLine("\n\r ------ Antes ------ \n\r ");

        //
        // Repassando para o próximo middleware
        //
        await _next(context);

        //
        // Neste ponto pode ser escrita a lógica do programa
        //
        Console.WriteLine("\n\r ------ Depois ------ \n\r ");
    }
}

//
// Criando uma extensão do aplication builder para utilizar o MeuMiddleware
//
public static class MeuMiddlewareExtension
{
    //
    // Criando um método de extensão "UseMeuMiddleware" dentro da instancia "builder" da interface "IApplicationBuilder" 
    //
    public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MeuMiddleware>();
    }
}