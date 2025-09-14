# Lines/members with AOT Problems

The following locations emit AOT/trimmer warnings that cannot be resolved by adding DynamicallyAccessedMembers attributes (RequiresDynamicCode / reflection-based runtime code generation). These are recorded so we can accept or address them by refactor or documentation instead of attributes.

- `src/DryIoc/Container.cs:15393` — PrintTools.Print → calls `System.Type.MakeGenericType(Type[])` (IL3050 RequiresDynamicCode)
- `src/DryIoc/Container.cs:1490` — `Container.GetDecoratorExpressionOrDefault` → `MethodInfo.MakeGenericMethod(Type[])` (IL3050 / IL2060)
- `src/DryIoc/Container.cs:1373` — delegate factory path → `Type.MakeGenericType(Type[])` (IL3050)
- `src/DryIoc/FastExpressionCompiler.cs:510` — ExpressionCompiler.TryCompileBoundToFirstClosureParam → `DynamicMethod` creation (IL3050)
- `src/DryIoc/FastExpressionCompiler.cs:461` — ExpressionCompiler.CompileNoArgsNew → `DynamicMethod` creation (IL3050)
- `src/DryIoc/Expression.cs:997` — NewArrayInit/NewArrayBounds → `Type.MakeArrayType()` (IL3050)
- `src/DryIoc/Container.cs:11830` and `src/DryIoc/Container.cs:12460` — multiple locations using `Type.MakeGenericType` in factory generation (IL3050 / IL2055)
- `src/DryIoc/Container.cs:5214` — WrappersSupport.GetLazyEnumerableExpressionOrDefault → `Type.MakeGenericType` / `MethodInfo.MakeGenericMethod` (IL3050 / IL2060)
- `src/DryIoc/Container.cs:3372` and many Interpreter/Converter locations — `MethodInfo.MakeGenericMethod(Type[])` used at runtime (IL3050 / IL2060)
- `src/DryIoc/Container.cs:15491` & `15499` — Portable.GetAssemblyTypesMethod uses many Assembly APIs that are marked RequiresUnreferencedCode / RequiresAssemblyFiles (IL2026 / IL3002)

Notes:
- These warnings indicate runtime code generation or assembly scanning that the linker can't guarantee availability for; attributes won't help because the problem is that members like MakeGenericType/MakeGenericMethod/DynamicMethod require dynamic code generation or cause unreferenced-code risks.
- For these members we should either accept/document them as Native AOT unsupported, refactor to avoid dynamic code, or mark the API with RequiresDynamicCode/RequiresUnreferencedCode where appropriate.

