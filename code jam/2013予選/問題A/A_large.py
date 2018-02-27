#! python3
# coding: utf-8
from sys import stdin, stderr

#黒い円を書いた後に残るインクの量を求める
def remInk(r, s, t):
    r = r + 1 #今回書く黒い円の半径
    s = r**2 - s #今回書く黒い円の面積
    t = t - s
    return t

def main():
    T = int(stdin.readline()[:-1])
    for i in range(T):
        r, t = [int(x) for x in stdin.readline()[:-1].split()]
        s = r**2
        x = 0
        while t >= 0:
            t = remInk(r, s, t)
            x = x + 1
            r = r + 2
            s = r**2
        print("Case #" + str(i + 1) + ": " + str(x - 1))
    print("終了", file=stderr)

if __name__ == '__main__':
    main()
    '''
    実行時
    $ python A_small.py < A-small-practice.in > A-small-output.txt
    '''