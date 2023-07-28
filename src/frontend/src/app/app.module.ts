import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavegacaoModule } from './navegacao/navegacao.module';
import { VeiculoModule } from './veiculos/veiculo.module';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask';
import { BaseInterceptor } from './base/base.interceptor.service';
import { AppGuard } from './app.guard';
import { VitrineModule } from './vitrine/vitrine.module';

export const httpInterceptorProviders = [
  {provide: HTTP_INTERCEPTORS, useClass: BaseInterceptor, multi: true}
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    NgxMaskModule.forRoot({
      dropSpecialCharacters: true
    }),
    AppRoutingModule,
    NavegacaoModule,
    VeiculoModule,
    VitrineModule
  ],
  providers: [AppGuard, httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
