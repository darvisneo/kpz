using System;
using System.Collections.Generic;
using System.Text;

// Базовий клас для всіх елементів розмітки
public abstract class LightNode
{
    public abstract string OuterHtml { get; }
    public abstract string InnerHtml { get; }
}

// Клас для текстового вузла
public class LightTextNode : LightNode
{
    private string _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHtml => _text;
    public override string InnerHtml => _text;
}

// Клас для елементів розмітки
public class LightElementNode : LightNode
{
    private string _tagName;
    private DisplayType _displayType;
    private ClosingType _closingType;
    private List<string> _cssClasses;
    private List<LightNode> _children;

    public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
    {
        _tagName = tagName;
        _displayType = displayType;
        _closingType = closingType;
        _cssClasses = new List<string>();
        _children = new List<LightNode>();
    }

    public void AddChild(LightNode child)
    {
        _children.Add(child);
    }

    public void AddCssClass(string cssClass)
    {
        _cssClasses.Add(cssClass);
    }

    public override string OuterHtml
    {
        get
        {
            StringBuilder sb = new StringBuilder();

            // Відкриваючий тег
            sb.Append($"<{_tagName}");

            // CSS класи
            if (_cssClasses.Count > 0)
            {
                sb.Append($" class=\"{string.Join(" ", _cssClasses)}\"");
            }

            // Закриття тегу
            if (_closingType == ClosingType.SelfClosing)
            {
                sb.Append(" />");
                return sb.ToString();
            }
            else
            {
                sb.Append(">");
            }

            // Вміст тегу
            sb.Append(InnerHtml);

            // Закриваючий тег
            if (_closingType == ClosingType.WithClosingTag)
            {
                sb.Append($"</{_tagName}>");
            }

            return sb.ToString();
        }
    }

    public override string InnerHtml
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in _children)
            {
                sb.Append(child.OuterHtml);
            }
            return sb.ToString();
        }
    }
}

// Тип відображення елементу
public enum DisplayType
{
    Block,
    Inline
}

// Тип закриття тегу
public enum ClosingType
{
    SelfClosing,
    WithClosingTag
}

class Program
{
    static void Main(string[] args)
    {
        // Створення списку інгредієнтів
        var ul = new LightElementNode("ul", DisplayType.Block, ClosingType.WithClosingTag);
        ul.AddCssClass("ingredients-list");

        var li1 = new LightElementNode("li", DisplayType.Block, ClosingType.WithClosingTag);
        li1.AddChild(new LightTextNode("2 яйця"));
        ul.AddChild(li1);

        var li2 = new LightElementNode("li", DisplayType.Block, ClosingType.WithClosingTag);
        li2.AddChild(new LightTextNode("1 склянка борошна"));
        ul.AddChild(li2);

        var li3 = new LightElementNode("li", DisplayType.Block, ClosingType.WithClosingTag);
        li3.AddChild(new LightTextNode("200 мл молока"));
        ul.AddChild(li3);

        // Створення заголовка
        var h1 = new LightElementNode("h1", DisplayType.Block, ClosingType.WithClosingTag);
        h1.AddChild(new LightTextNode("Рецепт млинців"));

        // Створення абзацу
        var p = new LightElementNode("p", DisplayType.Block, ClosingType.WithClosingTag);
        p.AddChild(new LightTextNode("Змішайте всі інгредієнти та смажте на розігрітій сковороді."));

        // Створення основного контейнера
        var div = new LightElementNode("div", DisplayType.Block, ClosingType.WithClosingTag);
        div.AddCssClass("recipe-container");
        div.AddChild(h1);
        div.AddChild(ul);
        div.AddChild(p);

        // Виведення HTML
        Console.WriteLine(div.OuterHtml);

        Console.WriteLine("\nInner HTML of div:");
        Console.WriteLine(div.InnerHtml);

        Console.WriteLine("\nOuter HTML of ul:");
        Console.WriteLine(ul.OuterHtml);
    }
}