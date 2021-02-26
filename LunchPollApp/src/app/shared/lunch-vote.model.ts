import { LunchLocal } from './lunch-local.model';

export class LunchVote {
  voteId: number=0;
  userEmail: string='';
  created: Date;
  modified: Date;
  lunchLocal:LunchLocal;
}
