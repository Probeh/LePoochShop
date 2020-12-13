import { Endpoints, IEndpoint } from '@helpers/endpoint.interface'

export class AppSettings {
  public endpoints?: { [provider: string]: IEndpoint };
  public environment: { production: boolean, endpoints: Endpoints };
}
