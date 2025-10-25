import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/features/auth/models/user';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{
  /**
   *
   */
  user?: User;
  constructor(private authService: AuthService) {
    
  }
  ngOnInit(): void {
    this.authService.user().subscribe({
      next: (user) => {
        this.user = user!;
      }
    })
  }

}
