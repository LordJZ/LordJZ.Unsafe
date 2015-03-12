using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace LordJZ.Unsafe.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = args[0];
            AssemblyDefinition a = AssemblyDefinition.ReadAssembly(location);

            Collection<AssemblyNameReference> refs = a.MainModule.AssemblyReferences;
            //refs.Remove(refs.Single(r => r.Name == "LordJZ.Unsafe.Builder"));

            TypeDefinition t = a.MainModule.Types.Single(td => td.Name == "UnsafeOperations");

            Collection<MethodDefinition> methods = t.Methods;
            for (int i = 0; i < methods.Count; i++)
            {
                MethodDefinition m = methods[i];
                if (!m.IsPublic)
                    methods.RemoveAt(i--);
            }

            Collection<FieldDefinition> fields = t.Fields;
            for (int i = 0; i < fields.Count; i++)
            {
                FieldDefinition f = fields[i];
                if (!f.IsPublic)
                    fields.RemoveAt(i--);
            }

            foreach (MethodDefinition m in t.Methods)
            {
                switch (m.Name)
                {
                    case "ReferenceToIntPtr":
                    case "ObjectToIntPtr":
                    case "IntPtrToObject":
                    case "Cast":
                        MakeLdarg0(m);
                        break;
                }
            }

            string backup = location + ".original";
            File.Delete(backup);
            File.Move(location, backup);
            a.Write(location);
        }

        static void MakeLdarg0(MethodDefinition m)
        {
            Collection<Instruction> insns = m.Body.Instructions;
            insns.Clear();

            insns.Add(Instruction.Create(OpCodes.Ldarg_0));
            insns.Add(Instruction.Create(OpCodes.Ret));
        }
    }
}
