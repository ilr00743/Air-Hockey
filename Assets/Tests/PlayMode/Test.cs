using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test
{
    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("Level");
    }
    
    [Test]
    public void WhenStart_CurrentScoreShouldBe7()
    {
        var gameObject = new GameObject().AddComponent<LevelSettings>();
        Assert.AreEqual(7, gameObject.GetScoreToWin());
    }

    [Test]
    public void GoalsToWinShouldBeLessMaxGoalsQuantity()
    {
        var gameObject = new GameObject().AddComponent<LevelSettings>();
        gameObject.AddGoalsToWin();
        Assert.Less(gameObject.GetScoreToWin(), 20);
    }

    [Test]
    public void WhenLevelStart_AIShouldBeOnStartPosition()
    {
        var ai = new GameObject().AddComponent<AI>();
        Assert.AreEqual(new Vector2(0, 4), ai.StartPosition);
    }
}
