﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextManager : SingleTon<StartTextManager> {

    public Text title;
    public Text intro;

    public void ChangeIntroText(int id) {
        if (id == 1)
        {
            title.text = "옥포 해전";
            intro.text = "1592년  4월 14일, 임진왜란이 발발하였습니다.\n일본의 공격이 개시되자마자 원균이 1만의 경상 수군을 해산하고 도망쳤습니다.\n\n5월 7일 아침, 옥포 앞바다에서 왜선 50여척이 발견되었다는 소식이 있었습니다..\n일본 함대를 요격하고 임진왜란 첫 승리를 거두십시오.";
        }
        else if (id == 2)
        {
            title.text = "사천 해전";
            intro.text = "옥포, 합포 적진포에서의 큰 손실에도 불구하고,\n왜군은 아직도 서해로의 진출 기회를 호시탐탐 엿보고 있습니다.\n\n정박해 있는 적을 끌어내기 위한 유인 작전이 성공해, 적은 우리를 향해 진격해오고 있습니다.\n실전배치된 거북선과 함께, 전투를 승리로 이끌어 주십시오.";
        }
        else if (id == 3)
        {
            title.text = "당포 해전";
            intro.text = "사천에서까지 패배한 왜군의 손실은 실로 막대하였으나, 그럼에도 당포 앞바다에는 아직 20척의 함선이 남아있습니다.\n출정하여 적을 모두 섬멸해 주십시오";
        }
        else if (id == 4)
        {
            title.text = "당항포 해전";
            intro.text = "주민들에게 당항포 앞바다에 20여척의 함선이 정박해 있다는 소식을 입수하였습니다.\n출정하여 적을 모두 섬멸해 주십시오.";
        }
        else if (id == 5)
        {
            title.text = "한산도 해전";
            intro.text = "지난 우리의 연이은 승전에도 불구하고, 육지의 상황은 그리 좋지 않았습니다.\n이를 만회하기 위해, 와키자카 야스하루는 73척의 대군을 이끌고 견내량에서 기회를 엿보고 있습니다.\n수적으로도 우리가 열세이지만, 지형 또한 우리가 활동하기엔 너무 좁습니다.\n왜군을 한산도 앞바다까지 끌어내어 섬멸하십시오.";
        }
        else if (id == 6)
        {
            title.text = "안골포 해전";
            intro.text = "한산도에서의 큰 승리 이후, 안골포에도 대규모의 적이 있다는 정보를 입수했습니다.\n안골포에서 적을 유인해 격멸하십시오.";
        }
        else if (id == 7)
        {
            title.text = "부산포 해전";
            intro.text = "경상우도순찰사가 왜군이 군수물자를 속속 부산으로 옮기고 있다는 소식을 전해 왔습니다.\n이는 전황이 불리해지자 도망치려는 낌새가 확실합니다.\n한편, 부산포 앞바다는 도요토미가 400여척의 적선을 이끌고 정박 중입니다.\n이 함대를 어찌하지 못한다면, 제해권을 확보하기 어려울 것입니다.\n부산포 앞바다로 가 다신 해전을 벌일 생각을 하지 못하도록, 적을 섬멸해 주십시오.";
        }
        else if (id == 8)
        {
            title.text = "명량 해전";
            intro.text = "칠천량에서의 기록적인 패전으로 조선 수군은 사방으로 패주하였습니다.\n삼도수군통제사 원균은 사망하였고, 남은 전선은 고작 12척뿐입니다.\n한편, 왜군은 이 기세를 몰아 서해로의 진출로를 확보하기 위해 전선 133척을 이끌고 진격하고 있습니다.\n여기서 왜놈들을 막지 못한다면 이번 전쟁은 패배하게 될 것입니다.";
        }
        else if (id == 9)
        {
            title.text = "노량 해전";
            intro.text = "명량에서의 기적적인 승리 이후, 곳곳에 흩어졌던 조선 수군을 규합하는데 성공했습니다.\n명으로부터 진린이 함대를 이끌고 지원에 나섰습니다.\n한편 일본에서 도요토미 히데요시가 죽자, 왜군은 철수를 준비하고 있습니다.\n순천왜성에 주둔하고 있는 대규모의 일본군이 철수하는 것을 막으려면, 노량에서 기습할 필요가 있을 것 같습니다.";
        }
    }
}
