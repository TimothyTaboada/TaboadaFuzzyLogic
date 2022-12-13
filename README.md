# TaboadaFuzzyLogic
## Oh lawd what is he gon do this time?
So there's this dating sim from 2014 called Artificial Academy 2 that has [this really janky relationship mechanic](https://wiki.anime-sharing.com/hgames/index.php?title=Artificial_Academy_2/Gameplay/Favorability_Rating) which seems like it'd be absolutely *fantastic* to replicate using Fuzzy Logic.

## What I wrote down on a text file while brainstorming
### Love Like Dislike Hate (LLDH) system from AA2
- Queue size 30
- Status based on # of Favourability Points (FP)
- Dequeue when > 30
- In the game Dislike is treated more like Neutral

### Display highest status  
Ex:  
(Lo = 13, Li = 14, D = 2, H = 1) 
Displays:
> Closer Than Friends, Not Quite Lovers

But if it were (Lo = 14, Li = 13, D = 2, H = 1)   
It would display either:  
> I Think I Like Them...

or

> Closer Than Friends, Not Quite Lovers

Depending on the previous status  
(ik this explanation sucks but its the best i can do given the 10 hours ive played it)

### Fuzzy Conditions
- If FP < 30 status is "Don't Know"
- LOW (0-10), MODERATE (11-20), HIGH (21-30)

-Love-
> I Think I Like Them... (MODERATE)

> Hate But Love (MODERATE Love & Hate; Love > Hate)

> No Doubt It's Love! (HIGH)

-Like-
> Acquaintance (LOW)

> I'm Curious! (LOW Love & Like)

> Friend (MODERATE)

> Closer Than Friends, Not Quite Lovers (MODERATE Like & Love)

> Good Buddies (HIGH)

-Dislike-
> Who? (MODERATE)

> (´・ω・`) (MODERATE Love & Dislike)

> No Interest (HIGH)

-Hate-
> Not Good With These Types (MODERATE)

> Love But Hate (MODERATE Love & Hate; Hate > Love)

> Don't Want To Get Involved (HIGH)