import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExperiencePostingComponent } from './experience-posting.component';

describe('ExperiencePostingComponent', () => {
  let component: ExperiencePostingComponent;
  let fixture: ComponentFixture<ExperiencePostingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExperiencePostingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExperiencePostingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
