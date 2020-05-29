import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class UserAddressBase {

//#region userAddressId Prop
        @prop()
        userAddressId : number;
//#endregion userAddressId Prop


//#region appUserId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        appUserId : number;
//#endregion appUserId Prop


//#region houseNumber Prop
        @required()
        @maxLength({value:10})
        houseNumber : string;
//#endregion houseNumber Prop


//#region area Prop
        @required()
        @maxLength({value:20})
        area : string;
//#endregion area Prop


//#region landmark Prop
        @maxLength({value:50})
        landmark : string;
//#endregion landmark Prop


//#region city Prop
        @required()
        @maxLength({value:20})
        city : string;
//#endregion city Prop


//#region state Prop
        @required()
        @maxLength({value:50})
        state : string;
//#endregion state Prop


//#region addressType Prop
        @required()
        @maxLength({value:10})
        addressType : string;
//#endregion addressType Prop



}