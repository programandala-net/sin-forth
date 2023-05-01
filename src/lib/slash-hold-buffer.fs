\ lib/slash-hold-buffer.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230430T0906+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require c-constant.fs \ `c-constant`

compiler{ /hold-buffer } cconstant /hold-buffer

  \ doc{
  \
  \ /hold-buffer ( -- len ) "slash-hold-buffer"
  \
  \ A `cconstant`. _len_ is the length of the pictured output string
  \ buffer: `hold-buffer`.
  \
  \ NOTE: There's also a homonymous compiler constant, whose value is
  \ used to define this target ``/hold-buffer`` and which can be used
  \ during compilation with ``compiler{ /hold-buffer }``.
  \
  \ See also: `hld`, `<#`, `/pad`.
  \
  \ }doc
