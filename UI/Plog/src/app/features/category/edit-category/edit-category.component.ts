import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy{

  id: string | null = null;
  paramSubscription?: Subscription;

  constructor(private route: ActivatedRoute) {
  }



  ngOnInit(): void {
   this.paramSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
  }

}
