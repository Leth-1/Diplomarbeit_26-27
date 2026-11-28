namespace Ara.Core.Konten;

/// <summary>Die zwei Rollen aus dem Lastenheft (F02).</summary>
public static class Rollen
{
    public const string Studierende = "Studierende";
    public const string Personal = "Personal";

    public static readonly IReadOnlyList<string> Alle = [Studierende, Personal];
}
