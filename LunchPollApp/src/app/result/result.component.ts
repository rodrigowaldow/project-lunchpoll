import { Component, OnInit } from '@angular/core';
import { LunchLocalService } from './../../app/shared/lunch-local.service';
import { LunchLocal } from './../../app/shared/lunch-local.model';
import { Chart } from 'angular-highcharts';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styles: [
  ]
})
export class ResultComponent implements OnInit {
  public chart: any;
  public totalVotes: any;
  public resultList: LunchLocal[];

  constructor(public service:  LunchLocalService) { }

  ngOnInit(): void {
    this.service.getTotalVotes()
      .subscribe( res => {
        this.totalVotes = res;
        console.log(res)
      });

    this.service.getLocals()
    .then( res => {
      this.resultList = res;
      console.log(res)

      for (let i = 0; i < res.length; i++) {
        res[i].voteShare = (((res[i].voteCount) / this.totalVotes) * 100);
      }
  
        this.createCharts();
    });
  }

  createCharts() {
    this.chart = new Chart({
      chart: {
        type: 'column'
      },
      title: {
        text: 'Votos recebidos por local'
      },
      xAxis: {
        type: 'category',
        labels: {
          rotation: -45,
          style: {
            fontSize: '13px',
            fontFamily: 'Verdana, sans-serif'
          }
        }
      },
      yAxis: {
        min: 0,
        title: {
          text: 'Percentual de Votos'
        }
      },
      legend: {
        enabled: false
      },
      tooltip: {
        pointFormat: 'Votos: <b>{point.y:.2f} %</b>'
      },

      series: [{
        type: 'column',
        data: [
          { name: this.resultList[0].localName, y: this.resultList[0].voteShare, color: 'rgba(253, 185, 19, 0.85)' },
          { name: this.resultList[1].localName, y: this.resultList[1].voteShare, color: 'rgba(0, 76, 147, 0.85)' },
          { name: this.resultList[2].localName, y: this.resultList[2].voteShare, color: 'rgba(170, 69, 69, 0.85)' },
          { name: this.resultList[3].localName, y: this.resultList[3].voteShare, color: 'rgba(112, 69, 143, 0.85)' },
          { name: this.resultList[4].localName, y: this.resultList[4].voteShare, color: 'rgba(0, 93, 160, 0.85)' },
          { name: this.resultList[5].localName, y: this.resultList[5].voteShare, color: 'rgba(45, 77, 157, 0.85)' },
          { name: this.resultList[6].localName, y: this.resultList[6].voteShare, color: 'rgba(0, 0, 0, 0.85)' },
        ],
      }]

    });

  }
}
