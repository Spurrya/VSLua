﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageService.Formatting
{
    internal static class TokenRange
    {
        internal static List<TokenType> AnyVisible =
            TokenRange.Fill(
                Enum.GetValues(typeof(TokenType)),
                new TokenType[] { TokenType.EndOfFile, TokenType.Unknown });

        internal static List<TokenType> All =
            TokenRange.Fill(
                Enum.GetValues(typeof(TokenType)),
                new TokenType[] { }); // Might need to add TokenType.Unknown to skip

        internal static List<TokenType> BinaryOperators =
            new List<TokenType>
            {
                TokenType.AndBinop,
                TokenType.BitwiseAndOperator,
                TokenType.BitwiseLeftOperator,
                TokenType.BitwiseOrOperator,
                TokenType.BitwiseRightOperator,
                TokenType.EqualityOperator,
                TokenType.ExponentOperator,
                TokenType.FloorDivideOperator,
                TokenType.DivideOperator,
                TokenType.GreaterOrEqualOperator,
                TokenType.GreaterThanOperator,
                TokenType.LessOrEqualOperator,
                TokenType.LessThanOperator,
                TokenType.MinusOperator,
                TokenType.ModulusOperator,
                TokenType.MultiplyOperator,
                TokenType.NotEqualsOperator,
                TokenType.OrBinop,
                TokenType.PlusOperator,
                TokenType.StringConcatOperator,
                TokenType.TildeUnOp,
                TokenType.VarArgOperator,
            };

        internal static List<TokenType> Brackets = new List<TokenType>
        {
            TokenType.OpenBracket,
            TokenType.CloseBracket,
            TokenType.OpenCurlyBrace,
            TokenType.CloseCurlyBrace,
            TokenType.OpenParen,
            TokenType.CloseParen,
        };

        internal static List<TokenType> Value = new List<TokenType>
        {
            TokenType.Number,
            TokenType.String,
            TokenType.FalseKeyValue,
            TokenType.TrueKeyValue,
            TokenType.NilKeyValue,
            TokenType.Identifier,
        };

        private static List<TokenType> Fill(Array values, TokenType[] exclude)
        {

            List<TokenType> tokenTypes = new List<TokenType>();

            foreach (TokenType tokenType in values)
            {
                if (!exclude.Contains(tokenType))
                {
                    tokenTypes.Add(tokenType);
                }
            }

            return tokenTypes;
        }

    }
}
