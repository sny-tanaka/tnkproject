#! python3
# coding: utf-8
from sys import stdin, stderr

#W番目のカードがカット前は何番目だったのかを帰納的に得る
def shuffle(C, W, A, B):
    for i in range(C)[::-1]:
        if W <= B[i]:
            W = W + A[i] - 1
        elif W <= A[i] + B[i] - 1:
            W = W - B[i]
    return W

def main():
    T = int(stdin.readline()[:-1])
    for i in range(T):
        lineT = stdin.readline()[:-1].split()
        M, C, W = int(lineT[0]), int(lineT[1]), int(lineT[2])
        A, B = [], []
        for times in range(C):
            lineC = stdin.readline()[:-1].split()
            A.append(int(lineC[0]))
            B.append(int(lineC[1]))
        ans = shuffle(C, W, A, B)
        print("Case #" + str(i + 1) + ": " + str(ans))
    print("終了", file=stderr)

if __name__ == '__main__':
    main()
    '''
    実行時
    $ python A_large.py < A-large-practice.in > A-large-output.txt
    '''