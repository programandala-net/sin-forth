\ lib/slash-pad.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230430T0804+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require constant.fs \ `constant`

compiler{ /pad } constant /pad

  \ doc{
  \
  \ /pad ( -- len ) "slash-pad"
  \
  \ A `constant`. _len_ is the length of `pad`.
  \
  \ NOTE: There's also a homonymous compiler constant, whose value is
  \ used to define this target ``/pad`` and which can be used during
  \ compilation with ``compiler{ /pad }``.
  \
  \ See also: `/hold`.
  \
  \ }doc
