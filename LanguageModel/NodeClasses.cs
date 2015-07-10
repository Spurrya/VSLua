﻿namespace LanguageModel {
	using System;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
    using ImmutableObjectGraph.CodeGeneration;


    [GenerateImmutable(GenerateBuilder = false)]
    public partial class SyntaxNode
    {
        [Required]
        int startPosition;
        [Required]
        int length;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class ChunkNode : SyntaxNode
    {
        [Required]
        readonly Block programBlock;
        [Required]
        readonly Token endOfFile;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class Block : SyntaxNode
    {
        [Required]
        ImmutableList<SyntaxNode> children;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class ElseBlock : SyntaxNode
    {
        readonly Token elseKeyword;
        readonly Block block;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class ElseIfBlock
    { //TODO: file bug: inherit from syntax node
        readonly int startPosition;
        readonly int length;
        readonly Token elseIfKeyword;
        readonly Expression exp;
        readonly Token thenKeyword;
        readonly Block block;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class IfNode : SyntaxNode
    {
        readonly Token ifKeyword;
        readonly Expression exp;
        readonly Token thenKeyword;
        readonly Block ifBlock;
        readonly ImmutableList<ElseIfBlock> elseIfList;
        readonly ElseBlock elseBlock;
        readonly Token endKeyword;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class Expression : SyntaxNode
    {
        ImmutableList<GenericExpression> expressions;

        public bool IsValidExpression()
        {
            //TODO: implement to check if there is a binop and then a missing exp or if there is a missing token or something
            return false;
        }
    }

    //The following level of abstraction is to deal with ambiguities
    [GenerateImmutable(GenerateBuilder = false)]
    public partial class GenericExpression
    {
        Token unop;
        ConcreteExpression exp;
        Token binop;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class ConcreteExpression { }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class SimpleExpression : ConcreteExpression
    {
        Token expressionValue;
    }

    [GenerateImmutable(GenerateBuilder = false)]
    public partial class ComplexExpression : ConcreteExpression
    {
        SyntaxNode expressionValue;
    }
}
