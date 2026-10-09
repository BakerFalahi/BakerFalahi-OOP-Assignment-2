public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int count = 0;

        for (int i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
                count++;
        }

        int maximum = count;

        for (int right = k; right < s.Length; right++)
        {
            if (IsVowel(s[right - k]))
                count--;

            if (IsVowel(s[right]))
                count++;

            if (count > maximum)
                maximum = count;
        }

        return maximum;
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i'
            || c == 'o' || c == 'u';
    }
}
