export interface IAppConfig {
    env: {
        name: string;
    };
    api: {
        acePort: string;
        onlyForTest: string;
    }
}
