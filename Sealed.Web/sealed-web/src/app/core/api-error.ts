export class ApiError {
    errorMessage: string;
    errorCode: number;

    constructor(error: string, code: number) {
        this.errorMessage = error;
        this.errorCode = code;
    }
}