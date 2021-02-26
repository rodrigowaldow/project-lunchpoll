import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Local } from 'protractor/built/driverProviders';
import { LunchLocal } from '../shared/lunch-local.model';
import { LunchVote } from '../shared/lunch-vote.model';
import { LunchLocalService } from './../../app/shared/lunch-local.service';

@Component({
  selector: 'app-poll',
  templateUrl: './poll.component.html',
  styles: [
  ]
})
export class PollComponent implements OnInit {

  constructor(public service:  LunchLocalService, public router: Router, private modalService: NgbModal) { }
  public selectedLocal: LunchLocal;
  public userVote: LunchVote;

  ngOnInit(): void {
    this.service.getLocals();
  }

  addVote(){
    console.log('addVote')
    console.log(this.selectedLocal)
    this.service.localData = Object.assign({}, this.selectedLocal);
    this.service.saveVote().subscribe(
      res => {
        this.modalService.dismissAll();
        this.router.navigate(['/results']);
      },
      err => {
        console.log(err);
      }
    );
  }

  confirmVote(content, selectedLocal) {
    this.selectedLocal = selectedLocal;
    console.log(this.selectedLocal)
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }
}
