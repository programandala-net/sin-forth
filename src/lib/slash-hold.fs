\ lib/slash-hold.fs

\ This file is part of Sin Forth.

\ This file adds `/hold` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261815.
\ See change log at the end of the file.

\ ==============================================================

require c-constant.fs \ `cconstant`

get-order get-current

target-definitions

80 cconstant /hold

  \ doc{
  \
  \ /hold ( -- len ) "slash-hold"
  \
  \ A `cconstant`. _len_ is the length of the pictured
  \ output string buffer, which is located right below `pad`.
  \
  \ The default value of ``/hold`` is 80. It may be changed by
  \ `c!>`.
  \
  \ See also: `hld`, `<#`, `/pad`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
