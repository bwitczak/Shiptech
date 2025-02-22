# # save this as shell.nix
# {pkgs ? import <nixpkgs> {}}:
# pkgs.mkShell {
#   packages = [pkgs.nodejs_22 pkgs.pnpm pkgs.dotnet-sdk];
# }
{pkgs ? import <nixpkgs> {}}: let
in
  pkgs.mkShell {
    buildInputs = with pkgs; [
      alejandra
      nodejs_22
      pnpm
      dotnet-sdk
      dotnet-runtime
      dotnet-ef
    ];

    shellHook = ''
      export DOTNET_ROOT=${pkgs.dotnet-sdk}
      export PATH=$DOTNET_ROOT/bin:$PATH
    '';
  }
