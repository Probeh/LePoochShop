import { Endpoints, IEndpoint } from '@assets/helpers/endpoint.interface'

export class AppSettings {
  public endpoints?: { [provider: string]: IEndpoint };
  public environment: { production: boolean, endpoints: Endpoints };
}
