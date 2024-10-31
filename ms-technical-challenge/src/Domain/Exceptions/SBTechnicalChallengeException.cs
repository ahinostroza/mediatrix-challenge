namespace SB.TechnicalChallenge.Domain;
using System;
using System.Runtime.Serialization;

public class SBTechnicalChallengeException : Exception
{
    public SBTechnicalChallengeException()
    { }

    public SBTechnicalChallengeException(string message)
        : base(message)
    { }

    public SBTechnicalChallengeException(string message, Exception innerException)
        : base(message, innerException)
    { }

    protected SBTechnicalChallengeException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
