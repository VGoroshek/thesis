using System;
using System.Collections.Generic;
public interface IInput
{
    Boolean CheckInconsistency(IInput seq2);

    List<IInput> GetChildren();
    List<IInput> GetParents();
}
