using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource buildSE;
    public AudioSource cancelSE;
    public AudioSource sellSE;
    public AudioSource upgradeSE;
    public AudioSource activeSE;

    public void playBuildSe() { this.buildSE.Play(); }
    public void playCancelSe() { this.cancelSE.Play(); }
    public void playUpgradeSe() { this.upgradeSE.Play(); }
    public void playSellSe() { this.sellSE.Play(); }
    public void playActiveSe() { this.activeSE.Play(); }
}
