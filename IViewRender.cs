﻿namespace Businesslogic.Interfaces
{
    public interface IViewRender
    {
        string Render<TModel>(string name, TModel model);
    }
}