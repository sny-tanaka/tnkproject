#! python3
# coding: utf-8
from sys import stdin, stderr

#その日最も満足度の高いコーヒーを選択する
def selectcoffee(coffeelist, times):
    i = -1 #初期化
    #消費期限がtimes以上のもので一番左の項を選択
    for x in range(len(coffeelist)):
        if coffeelist[x][1] >= times:
            i = x
            break
    #満足度の最大を抽出
    if i != -1:
        mx = coffeelist[i][2]
        coffeelist[i][0] = coffeelist[i][0] - 1
        if coffeelist[i][0] == 0:
            coffeelist.pop(i) #残数が０になったものはリストから削除
        return mx
    else:
        return 0

def main():
    T = int(stdin.readline()[:-1])
    for i in range(T):
        N, K = [int(x) for x in stdin.readline()[:-1].split()]
        coffeelist = []
        maxSatisfy = 0
        for kinds in range(N): #リスト内に３つセットでリストを入れ子にする
            coffeelist.append(list([int(x) for x in stdin.readline().split()]))
        for times in range(K, 0, -1): #最終日から逆算していく
            coffeelist.sort(key=lambda x: x[0], reverse=True); coffeelist #残数降順でソート
            coffeelist.sort(key=lambda x: x[2], reverse=True); coffeelist #満足度降順でソート
            maxSatisfy = maxSatisfy + selectcoffee(coffeelist, times)
        print("Case #" + str(i + 1) + ": " + str(maxSatisfy))
    print("終了", file=stderr)

if __name__ == '__main__':
    main()
    '''
    実行時
    $ python B_small.py < B-small-practice.in > B-small-output.txt
    '''