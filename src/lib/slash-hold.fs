\ lib/slash-hold.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
