import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ProductAttributesComponent } from './admin/product-attributes/product-attributes.component';
import { RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './routes';
import { TextAttributeComponent } from './admin/product-attributes/attributes/text-attribute/text-attribute.component';
import { ProductLayoutComponent } from './admin/product/product-layout/product-layout.component';
import { CreateProductComponent } from './admin/product/create-product/create-product.component';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { ProductListComponent } from './admin/product/product-list/product-list.component';
import { SelectAttributeViewComponent } from "./admin/product-attributes/attributes/select-attribute/select-attribute-view/select-attribute-view.component";
import { SelectAttributeCreateComponent } from './admin/product-attributes/attributes/select-attribute/select-attribute-create/select-attribute-create.component';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';

@NgModule({
    declarations: [AppComponent, ProductAttributesComponent, AdminLayoutComponent, TextAttributeComponent, ProductLayoutComponent,
        CreateProductComponent,
        ProductListComponent,
        SelectAttributeCreateComponent,
        SelectAttributeViewComponent],
    bootstrap: [AppComponent],
    imports: [
        AppRoutingModule,
        CommonModule,
        HttpClientModule,
        ReactiveFormsModule,
        FormsModule,
        RouterModule,
        BrowserModule,
        MatSelectModule,
        BrowserAnimationsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatTabsModule,
        MatIconModule,
        MatCardModule,
        MatListModule,
    ]
})
export class AppModule { }
