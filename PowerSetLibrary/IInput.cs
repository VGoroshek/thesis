using System;
using System.Collections.Generic;
public interface IInput
{
    Boolean CheckInconsistency(IInput seq2);

    Boolean? IsWeaker(IInput seq2);

}
