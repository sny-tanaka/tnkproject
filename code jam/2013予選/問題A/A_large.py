#! python3
# coding: utf-8
from sys import stdin, stderr
'''
n+1本目の円の面積の一般項は
2r+4n+1
n+1本目までの円の面積の合計は
s = ∑[k=0→n](2r+4k+1)=2r(n+1)+(2n+1)(n+1)
t<sとなる最小のnが答えとなる
tの範囲も広いので二分探索で絞っていく
'''
#黒い円の累計消費インク量
def sInk(n, r):
    s =  2 * r * (n + 1) + (2 * n + 1) * (n + 1)
    return s

def main():
    T = int(stdin.readline()[:-1])
    for i in range(T):
        r, t = [int(x) for x in stdin.readline()[:-1].split()]
        flg = 0
        mxn = 2**60
        mnn = 0
        n = (mxn - mnn) // 2 + mnn
        s1 = sInk(n, r)
        s2 = sInk(n+1, r)
        while flg == 0:
            if s1 <= t < s2:
                print("Case #" + str(i + 1) + ": " + str(n))
                flg = 1
                break
            elif t == s2:
                print("Case #" + str(i + 1) + ": " + str(n - 1))
                flg = 1
                break
            else:
                if t < s1:
                    mxn = n
                elif t > s1:
                    min = n
                n = (mxn - mnn) // 2 + mnn
                s1 = sInk(n, r)
                s2 = sInk(n+1, r)
                
    print("終了", file=stderr)

if __name__ == '__main__':
    main()
    '''
    実行時
    $ python A_large.py < A-large-practice.in > A-large-output.txt
    '''