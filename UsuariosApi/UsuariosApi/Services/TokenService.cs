﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class TokenService
{
    public void GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fj47832jgf987h4537fvhbc3"));

        var signingCredentials =  
            new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );
    }
}