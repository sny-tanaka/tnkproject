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
        maxN = 2**60
        minN = 0
        sa = maxN - minN
        while sa != 1:
            n = (maxN + minN) // 2
            s = sInk(n, r)
            if s > t:
                maxN = n
            elif s < t:
                minN = n
            elif s == t:
                break
            sa = maxN - minN
        print("Case #" + str(i + 1) + ": " + str(n))           
    print("終了", file=stderr)

if __name__ == '__main__':
    main()
    '''
    実行時
    $ python A_large.py < A-large-practice.in > A-large-output.txt
    '''