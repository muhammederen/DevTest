import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CustomerType } from '../models/customerType.model';
import { CustomerService } from '../services/customer.service';
import { Validators } from '@angular/forms';
import {  CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  isSubmitted = false;
  customerTypeOptions: CustomerType[];
  customers: CustomerModel[];
  selectedCustomerTypeId: number;

  customerFormGroup = new FormGroup({
    customerName: new FormControl('', [Validators.required, Validators.minLength(5)]),
    customerType: new FormControl('', [Validators.required]),
  });

  get f() { return this.customerFormGroup.controls; }

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.GetCustomersTypes().subscribe(options => this.customerTypeOptions = options);
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  customerTypeSelected(value: any): any {
    console.log(value);
  }

  customerTypeChanged(customerType: any) {
    this.selectedCustomerTypeId = customerType.target.value;
  }

  submitNewCustomer() {
    this.isSubmitted = true;
    if (this.customerFormGroup.invalid) {
      return;
    }

    const model: CustomerModel = {
      customerName: this.customerFormGroup.get('customerName').value,
      customerTypeId: Number(this.selectedCustomerTypeId),
      customerId : null,
      customerType: null
    };

    this.customerService.CreateCustomer(model).then(() => {
      this.customerService.newCustomerAdded.emit(model);
    });


    this.customerService.newCustomerAdded.subscribe(x => {
      this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
    });

  }

}
