using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace TickTackToe
{
    class AI
    {
        private ScriptEngine m_engine = Python.CreateEngine();
        private ScriptScope m_scope = null;
        ScriptSource source;

        public void Init(string player)
        {
            m_scope = m_engine.CreateScope();
            m_scope.SetVariable("player", player);
            m_scope.SetVariable("ClearBox", BoxState.Clear);
            m_scope.SetVariable("XBox", BoxState.X);
            m_scope.SetVariable("OBox", BoxState.O);
            source = m_engine.CreateScriptSourceFromString(System.IO.File.ReadAllText("AI.py"), SourceCodeKind.AutoDetect);
           
        }

        public void MakeMove(GameControl gc)
        {
            m_scope.SetVariable("game", gc);          
            source.Execute(m_scope);
        }
    }
}
