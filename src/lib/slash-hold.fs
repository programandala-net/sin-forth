\ lib/slash-hold.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require c-constant.fs \ `cconstant`

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
