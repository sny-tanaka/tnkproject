#! python3
# coding: utf-8
from sys import stdin, stderr

#カットする処理
def cut(cardlist, n, m):
    cutted = cardlist[n-1:n-1 + m] #カットされる部分を抜き出す
    clist = cardlist[:n-1] + cardlist[n-1 + m:] #抜き出された部分以外をくっつける
    return cutted + clist #抜き出した部分を上に乗せる

def main():
    T = int(stdin.readline()[:-1])
    for i in range(T):
        M, C, W = [int(x) for x in stdin.readline()[:-1].split()]
        cardlist = list(range(1, M + 1)) #カードの初期順序
        for times in range(C):
            A, B = [int(x) for x in stdin.readline()[:-1].split()]
            cardlist = cut(cardlist, A, B)
        print("Case #" + str(i + 1) + ": " + str(cardlist[W-1]))
    print("終了", file=stderr)

if __name__ == '__main__':
    main()
    '''
    実行時
    $ python A_small.py < A-small-practice.in > A-small-output.txt
    '''